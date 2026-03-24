# 394. Decode String

## Problem

Given an encoded string, return its decoded string.

The encoding rule is: `k[encoded_string]`, where `encoded_string` inside the square brackets is repeated exactly **k** times.

- `k` is always a positive integer.
- The input is always valid (no extra spaces, brackets are well-formed, etc.).
- Original data contains no digits — digits are only used as repeat counts.
- The output length will never exceed 10⁵.

## Examples

| Input | Output |
|---|---|
| `"3[a]2[bc]"` | `"aaabcbc"` |
| `"3[a2[c]]"` | `"accaccacc"` |
| `"2[abc]3[cd]ef"` | `"abcabccdcdcdef"` |

---

## Solution

**Approach: Two Stacks**

The idea is to use two stacks to handle nested patterns:

1. **`countStack`** — saves how many times we need to repeat a string.
2. **`stringStack`** — saves the string built *before* entering a `[`.

Walk through each character:

| Character | Action |
|---|---|
| **Digit** | Build the number `k` (handles multi-digit numbers like `12`) |
| **`[`** | Push current `k` and `current` string onto stacks; reset both |
| **`]`** | Pop the count and previous string; repeat `current` × count and append to previous |
| **Letter** | Append to `current` |

**Example step-by-step for `"3[a2[c]]"`:**

```
'3'  → k = 3
'['  → push(3, ""); k=0, current=""
'a'  → current = "a"
'2'  → k = 2
'['  → push(2, "a"); k=0, current=""
'c'  → current = "c"
']'  → repeat="cc", previous="a" → current = "acc"
']'  → repeat="accaccacc", previous="" → current = "accaccacc"
```

**Complexity:**
- Time: **O(n × k)** — proportional to the size of the output string.
- Space: **O(n)** — stack depth proportional to nesting level.
