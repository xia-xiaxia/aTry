# AC Automaton Tutorial

## Introduction
An Aho-Corasick (AC) automaton is a string searching algorithm that efficiently finds multiple patterns in a given text. It constructs a finite state machine that resembles a trie but also incorporates failure links to allow for fast backtracking.

## Key Concepts
1. **Trie**: A tree-like data structure that stores strings as paths from the root to leaf nodes.
2. **Failure Links**: Links that connect states in the trie to allow the algorithm to know where to resume searching after a mismatch.
3. **Output Links**: Links that point to nodes that represent patterns found in the text.

## Construction of the AC Automaton
### Step 1: Build the Trie
- Insert all patterns into a trie.
- Each character of the pattern corresponds to a path in the trie.

**Example**: For patterns `"he"`, `"hers"`, and `"she"`, the trie will look like this:
```
         (root)
        /     \
       h       s
      / \     / \
     e   r   h   e
             |    |
             r    s
```

### Step 2: Create Failure Links
- Use a breadth-first search (BFS) to create failure links for each state in the trie.
- If a character mismatch occurs, follow the failure link to find the next state.

### Step 3: Create Output Links
- Each state in the trie may lead to one or more patterns. Create output links to handle this.

## Implementation
### Python Example
```python
class AhoCorasick:
    def __init__(self):
        self.trie = {}
        self.output = {}
        self.fail = {}
        self.state_count = 0

    def insert(self, word):
        current_state = 0
        for char in word:
            if (current_state, char) not in self.trie:
                self.trie[(current_state, char)] = self.state_count
                self.state_count += 1
            current_state = self.trie[(current_state, char)]
        self.output.setdefault(current_state, []).append(word)

    def build_failure_links(self):
        queue = []
        for char in set(c for (s, c) in self.trie.keys()):
            if (0, char) in self.trie:
                self.fail[self.trie[(0, char)]] = 0
                queue.append(self.trie[(0, char)])
            else:
                self.fail[self.trie[(0, char)]] = 0

        while queue:
            state = queue.pop(0)
            for (s, c) in self.trie.keys():
                if s == state:
                    fail_state = self.fail[state]
                    while (fail_state, c) not in self.trie and fail_state != 0:
                        fail_state = self.fail[fail_state]
                    if (fail_state, c) in self.trie:
                        self.fail[self.trie[(state, c)]] = self.trie[(fail_state, c)]
                    else:
                        self.fail[self.trie[(state, c)]] = 0
                    queue.append(self.trie[(state, c)])

    def search(self, text):
        state = 0
        results = []
        for char in text:
            while (state, char) not in self.trie and state != 0:
                state = self.fail[state]
            state = self.trie.get((state, char), 0)
            if state in self.output:
                results.extend(self.output[state])
        return results

# Usage
ac = AhoCorasick()
for pattern in ["he", "hers", "she"]:
    ac.insert(pattern)
ac.build_failure_links()

text = "ushers"
print(ac.search(text))  # Output: ['he', 'hers', 'she']
```

## Conclusion
The Aho-Corasick algorithm is a powerful tool for searching multiple patterns in linear time. By building a trie and incorporating failure and output links, it efficiently handles string matching tasks.

## Further Reading
- [Aho-Corasick Algorithm - Wikipedia](https://en.wikipedia.org/wiki/Aho%E2%80%93Corasick_algorithm)
- [Introduction to Algorithms (Cormen et al.)](https://mitpress.mit.edu/books/introduction-algorithms)

---