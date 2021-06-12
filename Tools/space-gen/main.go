package main

import(
	"encoding/json"
	"flag"
	"fmt"
	"io/ioutil"
	"image"
	"image/color"
	"image/draw"
	"image/png"
	"math/rand"
	"os"
	"sort"
	"strconv"
)

type PropTemplate struct {
	img image.Image
	File string
	Nframes int
	PartWidth int
	PartHeight int
	Bias float32
}

type PropTemplateSort struct {
	propTemplates []PropTemplate
}

type PropInstance struct {
	PropTemplateIndex int
	X, Y int
	CurrentFrame int
}

const(
	W = 32 * 16
	H = 32 * 9
)

var (
	bg = color.RGBA{36, 27, 43, 255}
	propTemplates = make([]PropTemplate, 0)
	propInstances = make([]PropInstance, 0)
	jsonPath string
	outPath string
	nFrames int
)

func (p *PropTemplateSort) Len() int {
	return len(p.propTemplates)
}

func (p *PropTemplateSort) Swap(i, j int) {
	p.propTemplates[i], p.propTemplates[j] = p.propTemplates[j], p.propTemplates[i]
}

func (p *PropTemplateSort) Less(i, j int) bool {
	return p.propTemplates[i].Bias < p.propTemplates[j].Bias
}

func (p *PropInstance) Rect() image.Rectangle {
	return image.Rect(p.X, p.Y, p.X + propTemplates[p.PropTemplateIndex].PartWidth, p.Y + propTemplates[p.PropTemplateIndex].PartHeight)
}

func (p *PropInstance) DrawRect() image.Rectangle {
	w := propTemplates[p.PropTemplateIndex].PartWidth
	h := propTemplates[p.PropTemplateIndex].PartHeight

	ix := p.CurrentFrame % w
	iy := p.CurrentFrame / w

	x := ix * w
	y := iy * h
	return image.Rect(x, y, x + w, y + h).Add(image.Pt(p.X, p.Y))
	//return image.Rect(x, y, x + w, y + h)
}

func (p *PropInstance) DrawPosition() image.Rectangle {
	w := propTemplates[p.PropTemplateIndex].PartWidth
	h := propTemplates[p.PropTemplateIndex].PartHeight
	return image.Rect(p.X, p.Y, p.X + w, p.Y + h)
}

func (p *PropInstance) ImageOffset() image.Point {
	w := propTemplates[p.PropTemplateIndex].PartWidth
	h := propTemplates[p.PropTemplateIndex].PartHeight

	bigW := propTemplates[p.PropTemplateIndex].img.Bounds().Max.X
	nw := bigW / w

	ix := p.CurrentFrame % nw
	iy := p.CurrentFrame / nw

	x := ix * w
	y := iy * h
	return image.Pt(x, y)
}

func (p *PropInstance) Draw(target *image.RGBA) {
	//draw.Draw(target, p.DrawRect(), propTemplates[p.PropTemplateIndex].img, image.ZP, draw.Over)
	draw.Draw(target, p.DrawPosition(), propTemplates[p.PropTemplateIndex].img, p.ImageOffset(), draw.Over)
}

func (p *PropInstance) Update() {
	p.CurrentFrame++
	if p.CurrentFrame >= propTemplates[p.PropTemplateIndex].Nframes {
		p.CurrentFrame = 0
	}
}

func writeImg(img image.Image, dest string) error {
	f, err := os.Create(dest)
	if err != nil {
		return err
	}
	defer f.Close()
	err = png.Encode(f, img)
	return err
}

func randomPos(maxW int, maxH int) (int, int) {
	return rand.Intn(maxW - 16), rand.Intn(maxH - 16)
}

func newBlankFrame() *image.RGBA {
	img := image.NewRGBA(image.Rect(0,0,W,H))
	draw.Draw(img, img.Bounds(), &image.Uniform{bg}, image.ZP, draw.Src)
	return img
}

func genPropInstance(dest *image.RGBA) *PropInstance {
	//propType := rand.Intn(len(propTemplates))
	propType := 0
	rng := rand.Float32()
	for ; propType < len(propTemplates) - 1; propType++ {
		if rng < propTemplates[propType].Bias {
			break
		}
	}

	x, y := randomPos(W, H)
	currentFrame := rand.Intn(propTemplates[propType].Nframes)

	propInstance := &PropInstance{
		PropTemplateIndex: propType,
		X: x,
		Y: y,
		CurrentFrame: currentFrame,
	}

	newPropDims := propInstance.Rect()
	for _, other := range propInstances {
		otherPropDims := other.Rect()
		if newPropDims.Overlaps(otherPropDims) {
			return nil
		}
	}

	return propInstance
}

func prepareProps(img *image.RGBA) {
	for i := 0; i < 60; i++ {
		newProp := genPropInstance(img)
		if newProp != nil {
			propInstances = append(propInstances, *newProp)
			//newProp.Draw(img)
		}
	}
}

func applyPropsAndStep(img *image.RGBA) {
	for i := range propInstances {
		propInstances[i].Draw(img)
	}

	for i := range propInstances {
		propInstances[i].Update()
	}
}

func mergeImages(imgs []*image.RGBA) *image.RGBA {
	img := image.NewRGBA(image.Rect(0,0,W, H * nFrames))
	for i := range imgs {
		pt := image.Pt(0, i * H)
		draw.Draw(img, img.Bounds().Add(pt), imgs[i], image.ZP, draw.Src)
	}

	return img
}

func init() {
	flag.StringVar(&jsonPath, "src", "", "Json file specifying sprite generation")
	flag.StringVar(&outPath, "out", "result", "Out file basename")
	flag.IntVar(&nFrames, "frames", 1, "Amount of images to generate")
	flag.Parse()

}

func main() {
	if jsonPath == "" {
		fmt.Println("Please set 'src' flag")
		return
	}

	bytes, err := ioutil.ReadFile(jsonPath)
	if err != nil {
		panic(err)
	}

	err = json.Unmarshal(bytes, &propTemplates)
	if err != nil {
		panic(err)
	}

	for i := range propTemplates {
		file, err := os.Open(propTemplates[i].File)
		if err != nil {
			panic(err)
		}
		defer file.Close()
		propTemplates[i].img, _, err = image.Decode(file)
		if err != nil {
			panic(err)
		}
	}

	sort.Sort(&PropTemplateSort{propTemplates})
	allImgs := make([]*image.RGBA, 0, nFrames)
	img := newBlankFrame()
	prepareProps(img)

	for i := 0; i < nFrames; i++ {
		applyPropsAndStep(img)
		writeImg(img, outPath + "_" + strconv.Itoa(i) + ".png")
		allImgs = append(allImgs, img)
		img = newBlankFrame()
	}

	merged := mergeImages(allImgs)
	writeImg(merged, outPath + "_all.png")
}
