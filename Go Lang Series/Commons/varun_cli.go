package main

import (
	"bufio"
	"fmt"
	"os"
)

const projectCmd string = "project"

func main() {
	command := bufio.NewReader(os.Stdin)

	commandParts := command.Split(' ')

	var mainCommand string = commandParts[0]

	switch mainCommand {
	case projectCmd:
		commandArg := commandParts[1]
	default:
		fmt.Println("Invalid command")
	}
}
