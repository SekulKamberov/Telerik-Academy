## Dynamic Programming
### Homework
1. Write a program based on dynamic programming to solve the "`Knapsack Problem`": you are given N products, each has weight W<sub>i</sub> and costs C<sub>i</sub> and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and weight ≤ M. The numbers N, M, W<sub>i</sub> and C<sub>i</sub> are integers in the range [1..500].
  * _Example_: M=10 kg, N=6, products:
      * beer – weight=3, cost=2
      * vodka – weight=8, cost=12
      * cheese – weight=4, cost=5
      * `nuts – weight=1, cost=4`
      * ham – weight=2, cost=3
      * `whiskey – weight=8, cost=13`
  * _Optimal solution_:
      * nuts + whiskey
      * weight = 9
      * cost = 17
2. Write a program to calculate the "`Minimum Edit Distance`" (MED) between two words. `MED(x, y)` is the minimal sum of costs of edit operations used to transform `x` to `y`.
  * _Sample costs_:
      * cost (replace a letter) = 1
      * cost (delete a letter) = 0.9
      * cost (insert a letter) = 0.8
  * _Example_:
      * x = "developer", y = "enveloped" &rarr; cost = 2.7 
      * delete ‘d’:  "developer" &rarr; "eveloper", cost = 0.9
      * insert ‘n’:  "eveloper" &rarr; "enveloper", cost = 0.8
      * replace ‘r’ &rarr; ‘d’:  "enveloper" &rarr; "enveloped", cost = 1