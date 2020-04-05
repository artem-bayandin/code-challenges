Some algorithms from 'fast-coding' tasks (codility, test projects, etc)

## domino-sequence

- finds the longest path having provided dominos
- lib returns all possible paths so you may then select longest, shortest, any

## fizz-buzz

- game for children to learn dividors
- lib accepts any lists of divisors
- lib has three possible incoming lists of dividends: 1-to-N, M-to-N, array

## plane-seats-allocator

- how many families might be set in a plane with some allocated seats
- lib accepts rows 1..99, seat letters A..Z
- lib accepts any sequence of letters in a row (standard sequence 'A', 'B', 'C', 'D' and non-standard like 'G', 'O', 'D', 'P' are allowed)
- lib accepts any sequence that might be treated as a 'good one' (like 'b', 'c', 'd', 'e' for family of 4; and 'f', 'g', 'h' for family of 3)

## stringify-tree

- serialize/deserialize binary search tree into/from a string (usage of (16(8(4)(10(9)(11)))(20(17))) structure is not allowed)
- [not optimized]

## two-banners

- having a row of building we need to cover it with at most 2 banners with the least possible square
- [not optimized], correct but not efficient. should run 7.5k in < 50ms, 100k in < 3 sec on my machine (100ms / 6sec on codility)
