# ListNode

A lightweight implementation of a generic singly linked list in C#.

The project was created for educational purposes to better understand how linked lists work internally, how collection interfaces from .NET are implemented, and how to write comprehensive unit tests.

## Why **ListNode**?

The project name is a reference to [**LeetCode #2 — Add Two Numbers**](https://leetcode.com/problems/add-two-numbers/description/).

In that problem, numbers are represented as linked lists where each node stores a single digit in reverse order.

For example:

```
342 -> 2 -> 4 -> 3
465 -> 5 -> 6 -> 4
-------------------
807 -> 7 -> 0 -> 8
```

The task inspired the name **ListNode**, since the original problem revolves around manipulating linked list nodes.

Although this project implements a reusable linked list rather than solving the problem itself, its name pays tribute to one of the most well-known linked list problems on LeetCode.

## Features

* Generic implementation (`ListNode<T>`)
* Singly linked list
* Implements standard .NET collection interfaces:

  * `IEnumerable<T>`
  * `ICollection<T>`
  * `IList<T>`
* Supports:

  * Add
  * Insert
  * Remove
  * RemoveAt
  * Clear
  * Contains
  * IndexOf
  * CopyTo
  * Indexer (`[]`)
  * Enumeration with `foreach`

## Example

```csharp
var list = new ListNode<int>();

list.Add(1);
list.Add(2);
list.Insert(1, 10);

foreach (var value in list)
{
    Console.WriteLine(value);
}
```

Output:

```
1
10
2
```

## Project structure

```
src/
 └── ListNode

tests/
 └── ListNode.Test
```

## Testing

The project contains unit tests covering constructors, collection operations, indexers, enumeration, boundary cases, and exception scenarios.

Run all tests:

```bash
dotnet test
```

## Purpose

This project was built to practice:

* data structures
* generic programming
* implementation of .NET collection interfaces
* unit testing with xUnit
* edge-case handling
* clean and maintainable C# code

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
