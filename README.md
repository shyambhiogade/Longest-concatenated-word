# Longest-concatenated-word
.net application with longest concatenated word
this respository contains 

This repository contains a sample application to find the 
1.	The longest word in the file that can be constructed by concatenating copies of shorter words also found in the file.
2.	The program reports the 2nd longest word found
3.	Total count of how many of the words in the list can be constructed of other words in the list.

How it work.
1.	First all the words in the files are placed in data structure called Trie, Trie is best to find the prefix and suffix for a word.
2.	Also place all the words in a lookup structure a dictionary created with length of word as key and its value as actual string, sort it in descending according to the length of the word i.e. key.
3.	Now take each item in the sorted dictionary,
    1.	Get prefix from each word starting at the minimum word length, from actual word
    2.	check if prefix exist in Trie structure, if it doesn’t not then actual word is not the concanated word
    3.	check for remaining word as suffix, if prefix and suffix exist, then it’s a concatenated-word
    4.	if suffix doesn’t exist, starting from the smallest set of characters from suffix, find all word from suffix recursively in original word.
    5.	If both prefix and suffix is found, it’s a concanated word, add it in the list of result.
    6.	The first word in the result is the longest and so on.
    7.	Total length of the result array is no of the concanated word available. 
