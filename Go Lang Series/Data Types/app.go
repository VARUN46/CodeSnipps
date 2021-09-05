package main

import "fmt"

var x, y int = 1, 2

var a, b string = "a", "b"

var as, bs, x1, isVal = "a", "b", 1, true

const author = "Varun"

func main() {

	fmt.Println("Int Data Type")
	fmt.Println(x, y)
	fmt.Println(a, b)
	fmt.Println(as, bs, x1, isVal)

	noTypeSpecificInFunction := 7.123234

	fmt.Println(noTypeSpecificInFunction)

	fmt.Println(author)
}
