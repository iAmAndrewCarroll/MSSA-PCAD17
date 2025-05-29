

| File | Required Fields |
| ------------------- | ------------------- |
| **methodProblems.json**<br>**syntaxProblems.json** | `id`, `language`, `prompt`, `description`, `variables`, `example`                                                            |
| **methods.json**<br>**syntax.json**                | `id`, `title`, `description`, `variables`, `example`, `skills`, `common_errors`, `leetcode_tags` (methods) / `tags` (syntax) |
| **whiteboard.json**                                | `id`, `restate`, `logic_steps`, `edge_cases`, `pseudo_code`, **NEW:** `variables`, `example`                                 |


| Category                 | Ideas to future-proof your dataset                         |
| ------------------------ | ---------------------------------------------------------- |
| Tags (methods/syntax) | Add difficulty: `["Easy"]`, `["Medium"]`                   |
| Cognitive Focus       | `"focus": "parameter passing"` / `"focus": "loop control"` |
| Media Support         | `"video_url"` or `"hint_url"` for external explanation     |
| Test Inputs           | `"test_case": "Input: [2,4,6] → Output: [24,12,8]"`        |
| Metadata              | `"source": "MSSA Week 6 Day 3"` or `"assignment": "6.2.2"` |
