## Intro

One of the things we do at Euromoney is publish and manage content.
This assignment is to analyse text, detecting and filtering negative words.

- This assignment takes between 30 minutes and an hour.
- [NUnit](http://www.nunit.org) and [Moq](http://code.google.com/p/moq), references have been added using [NuGet](http://nuget.codeplex.com/) Packages.

## Task requirements

- All stories to be completed with an appropriate level of testing.
- No actual storage implementation or databases are required, feel free to stub or mock any data access you need.
- Reformat, refactor and rework the provided code in any way you see fit.
- Code must be supported by tests to be "done-done".

## Advice to candidates

- You should approach this task in the same way that you would a real, production assignment. Do not 'code to the test'. 
- It is more important that you show the right approach than that you complete all the stories. If you run low on time, apply an MVP to the stories. 
- We will assume that the code you produce for this exercise reflects the kind of code you would write in a real-world situation, and assess accordingly.

## Task Stories

Please complete each story in order.

---

### Story 1

As a **user**  
I want **see the number of negative words in a text input**  
So that **we can track the amount of negative content**

#### Acceptance criteria

- Total number of negative words output to screen
- Console output the total number of negative words and the phrase analysed
- Example output:
<pre>Scanned the text:
The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.
Total Number of negative words: 2
Press ANY key to exit.</pre>

---

### Story 2

As an **administrator**  
I want **to be able to change the set of negative words counted**  
So that **I don't need to change the code when we select new negative words or phrases**

#### Acceptance criteria

- Negative words retrieved from data store.
- Number of negative words found respects words available from the data store.

---

### Story 3

As a **reader**  
I want **negative words filtered out of the text**  
So that **our clients are not upset by negative language**

#### Acceptance criteria

- Any negative word in the text should have its middle replaced with hashes. <pre>"Horrible"</pre> should be outputted <pre>"H######e"</pre>.

---

### Story 4

As an **content curator**  
I want **disable negative word filtering on the command line**  
So that **I can see the original content**.

#### Acceptance criteria

- Count of negative words output
- Original text output

---

Note: Please submit your changes as a new pull request on *this* repo, and not on the original repo from which this is forked. If you can't submit a pull request then zip up your code and email it to us, but PRs are *strongly* preferred.

Thanks for your time, we look forward to hearing from you!
