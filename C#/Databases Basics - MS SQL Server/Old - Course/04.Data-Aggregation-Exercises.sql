--Problem 1. Records’ Count
--Import the database and send the total count of records from the one and only table to Mr. Bodrog. Make sure
--nothing got lost.

SELECT COUNT(*)
FROM WizzardDeposits

--Problem 2.	Longest Magic Wand
--Select the size of the longest magic wand. Rename the new column appropriately.
SELECT MagicWandCreator AS LongestMagicWand
FROM WizzardDeposits

