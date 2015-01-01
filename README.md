RubiksCube
==========

This is my attempt to represent a Rubik's Cube in code for a programming challenge. Right now rotations are done in a very ugly brute force way. Rotations can only be done clockwise but adding counterclockwise rotation should be pretty easy. Doing the rotations was more difficult than I initially thought it would be so I went this route just to get something working that I could improve later.

The purpose of the challenge was to input a series of moves and then report which faces the squares that were originally on the "Front" face were now located.

For example, this is what the front face looks like initially:

7 8 9

4 5 6

1 2 3

All other faces have values of zero for each of their squares.

If you rotated the Right face clockwise then the Front face would now look like this:

7 8 0

4 5 0

1 2 0

And the Up face would look like this:

0 0 9

0 0 6

0 0 3

So output would be:

F F U F F U F F U

...which means value 1 is on Front, 2 is on Front, 3 is on Up, etc.