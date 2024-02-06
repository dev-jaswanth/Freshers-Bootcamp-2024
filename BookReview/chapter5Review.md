# Chapter 5: The Art of Commenting

**Key Idea**: The primary goal of commenting is not just to explain what the code does, but to convey the writer's knowledge to the reader, ensuring they understand the intent and rationale behind the code as fully as the writer does.

## **1. What Not to Comment**

- **Redundancy**: Avoid comments that merely repeat what the code already clearly indicates.
  - **Example of Unnecessary Comment**:
    ```cpp
    // Constructor
    Account();
    ```

## **2. The Essence of Valuable Comments**

- **Clarification**: Comments should add new information or clarify complex code snippets.
  - **Good Example**:
    ```python
    # remove everything after the second '*'
    name = '*'.join(line.split('*')[:2])
    ```

- **Avoid Superficial Comments**: Comments that simply restate the code, without adding value, are unnecessary.
  - **Improvement Over Superficiality**:
    ```cpp
    // Find a Node with the given 'name' or return NULL.
    Node* FindNodeInSubtree(Node* subtree, string name, int depth);
    ```

## **3. Naming vs. Commenting**

- **Self-documenting Code**: Prioritize clear naming over comments that compensate for ambiguous names.
  - **From Ambiguous to Clear**:
    ```cpp
    // Before: void CleanReply(Request request, Reply reply);
    // After: void EnforceLimitsFromRequest(Request request, Reply reply);
    ```

## **4. Recording Your Thoughts**

- **"Director Commentary"**: Share insights or reasons behind choosing a specific implementation.
  - **Insightful Example**:
    ```cpp
    // Binary tree was 40% faster than a hash table for this data.
    ```

## **5. Future Code Insights**

- **Documenting Flaws and TODOs**: Mark parts of the code that need improvement, are incomplete, or present a workaround.
  - **Markers like TODO, FIXME, HACK, XXX** indicate areas that require attention.

## **6. Constants and Magic Numbers**

- **Tell the Story Behind Constants**: Provide context or reasoning for the chosen values.
  - **Contextual Example**:
    ```python
    NUM_THREADS = 8 # Chosen based on the number of processors.
    ```

## **7. Empathy for the Reader**

- **Anticipating Questions**: Comment on code sections that might confuse readers or where the rationale isn't immediately apparent.
  - **Preemptive Clarification**:
    ```cpp
    // This trick forces the vector to relinquish its memory.
    vector<float>().swap(data);
    ```

## **8. Big Picture Comments**

- **Overview and Workflow**: Help newcomers grasp the system's architecture and workflow through high-level comments.
  - **Helpful Overview**:
    ```python
    // This file handles the interface to the filesystem, managing permissions and details.
    ```

## **Final Thoughts**

- **Overcoming Commenting Hesitation**: Start with any comment that comes to mind and refine from there. The first step is to break the ice by jotting down your immediate thoughts, however unpolished they may seem.

This chapter emphasizes the nuanced art of commenting, steering clear from the trivial and focusing on imparting wisdom that genuinely aids the reader's understanding, contributing to a codebase that communicates its intentions clearly and effectively.
