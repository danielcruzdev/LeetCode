# 206. Reverse Linked List

**Difficulty:** Easy

## Problem

Given the `head` of a singly linked list, reverse the list and return the reversed list.

### Examples

**Example 1:**
```
Input:  head = [1, 2, 3, 4, 5]
Output: [5, 4, 3, 2, 1]
```

**Example 2:**
```
Input:  head = [1, 2]
Output: [2, 1]
```

**Example 3:**
```
Input:  head = []
Output: []
```

### Constraints

- The number of nodes is in the range `[0, 5000]`
- `-5000 <= Node.val <= 5000`

---

## Solution — Iterative Approach

The problem is solved using an **iterative in-place reversal** with two pointers.

### How it works

We traverse the list once, reversing each node's `next` pointer as we go:

```
Initial:  1 → 2 → 3 → 4 → 5 → null
Step 1:   null ← 1   2 → 3 → 4 → 5
Step 2:   null ← 1 ← 2   3 → 4 → 5
...
Final:    null ← 1 ← 2 ← 3 ← 4 ← 5   (new head = 5)
```

We keep track of three references at each step:

| Variable   | Purpose                                              |
|------------|------------------------------------------------------|
| `prev`     | Previously processed node (starts as `null`)         |
| `current`  | Node currently being processed                       |
| `nextTemp` | Saves next node before overwriting `current.next`    |

At each iteration:
1. Save `current.next` into `nextTemp` (preserves the rest of the list)
2. Point `current.next` to `prev` (reverses the pointer)
3. Advance `prev` to `current`
4. Advance `current` to `nextTemp`

When `current` becomes `null`, `prev` holds the new head of the reversed list.

### Complexity

| | |
|---|---|
| **Time**  | O(n) — single pass through the list |
| **Space** | O(1) — no extra data structures used |
