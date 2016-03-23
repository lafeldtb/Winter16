/************************************************************************
 * filename: anagrams.c													*
 *																		*
 * Reads from a dictionary of words and builds lists of anagrams		*
 * (see example dictionary files and output produced for each 			*
 * input/dictionary file).												*
 *																	o	*
 * An anagram is a word formed by rearranging the letters of another	*
 * word such as the word "cinema" formed from the word "iceman".		*
 *																		*
 * Author(s): 	Mattie Phillips and Ben LaFeldt							*
 ***********************************************************************/

#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#define INITIAL_ARRAY_SIZE 10000
#define MAX_WORD_SIZE 50

// node in a linked list
struct node {
	char *text;
	struct node *next;
};

typedef struct node Node;

// structure used for an array element
//		- head field points to the first element of a linked list
//		- size field stores number of nodes in the linked list
typedef struct {
	int size;
	Node *head;
} AryElement;

/************************************************************************
 * YOU MUST NOT DEFINE ANY GLOBAL VARIABLES (i.e., OUTSIDE FUNCTIONS).  *
 * COMMUNICATION BETWEEN FUNCTIONS MUST HAPPEN ONLY VIA PARAMETERS.     *
 ************************************************************************/

/************************************************************************
 * Function declarations/prototypes										*
 ************************************************************************/

AryElement *buildAnagramArray(char *infile, int *aryLen);

void printAnagramArray(char *outfile, AryElement *ary, int aryLen);

void freeAnagramArray(AryElement *ary, int aryLen);

void testAnagrams();

bool areAnagrams(char *word1, char *word2);

Node *createNode(char *word);


/************************************************************************
 * Main driver of the program.											*
 * The input file is assumed to contain one word (of lower case			*
 * letters only) per line.												*
 * Use the following commands to compile and run the program:			*
 *		$ gcc -Wall -std=c99 -o anagrams anagrams.c						*
 * 		$ ./anagrams  dictionary1.txt  output1.txt						*
 ************************************************************************/
int main(int argc, char *argv[])
{
	AryElement *ary;
	int aryLen;

	if (argc != 3) {
		printf("Wrong number of arguments to program.\n");
		printf("Usage: ./anagrams infile outfile\n");
		exit(EXIT_FAILURE);
	}

	char *inFile = argv[1];
	char *outFile = argv[2];
	
	ary = buildAnagramArray(inFile,&aryLen);

	printAnagramArray(outFile,ary,aryLen);

	freeAnagramArray(ary,aryLen);

	return EXIT_SUCCESS;
}

/************************************************************************
 * Takes a filename that contains one word (of lower case letters) per	*
 * line, reads the file contents, and builds an array of linked lists	*
 * and returns a pointer to this array. It also sets the aryLen 		*
 * parameter to size/length of the array returned from the function.	*
 ************************************************************************/
AryElement *buildAnagramArray(char *infile, int *aryLen)
{
	AryElement *ary = NULL;		// stores pointer to dynamically allocated array of structures
	char word[MAX_WORD_SIZE];	// stores a word read from the input file
	int curAryLen = INITIAL_ARRAY_SIZE;				// stores current length/size of the array
	int nbrUsedInAry = 0;		// stores number of actual entries in the freeAnagramArray		reallocate to this size  after we create the array
	AryElement dictionary[INITIAL_ARRAY_SIZE];	//Array we are building
	ary = dictionary;							//Pointer to this array we are building
	
	// prepare the input file for reading
	FILE *fp = fopen(infile,"r");
	if (fp == NULL) {
		fprintf(stderr,"Error opening file %s\n", infile);
		exit(EXIT_FAILURE);
	}	
	
	ary = malloc(INITIAL_ARRAY_SIZE * sizeof(AryElement));

	while(fgets(word, MAX_WORD_SIZE, fp) != NULL){
		if (curAryLen == nbrUsedInAry){
			curAryLen += 10000;
			ary = realloc(ary, curAryLen * sizeof(AryElement));
		}
		strtok(word, "\n");
		Node *wordToAdd = createNode(word);
		bool anagramFound = false;

		for (int i=0; i<nbrUsedInAry; i++){
			Node *head = ary[i].head;
			int size = ary[i].size;
			if (areAnagrams(wordToAdd->text, head->text)){
				anagramFound = true;
				for (int j=0; j<size; j++){
					if (head->next == NULL){
						head->next = wordToAdd;
					}
					else{
						head = head->next;
					}
				}
				ary[i].size = ary[i].size +1;
			}
		}
		if (!anagramFound){
			AryElement element;
			element.head = wordToAdd;
			element.size = 1;
			ary[nbrUsedInAry] = element;
			nbrUsedInAry += 1;
		}	
	}

	// TO DO
	printf(fscanf(fp, "%s"));
	ary = realloc(ary, nbrUsedInAry * sizeof(AryElement));

	fclose(fp);
	
	*aryLen = nbrUsedInAry;

    return ary;
}

/************************************************************************
 * Takes a filename used for output, a pointer to the array, and size	*
 * of the array, and prints	the list of anagrams (see sample output) 	*
 * to the file specified.												*
 ************************************************************************/
void printAnagramArray(char *outfile, AryElement *ary, int aryLen)
{
	FILE *fp = fopen(outfile, "w");
	if (fp == NULL) {
		fprintf(stderr,"Error opening file %s\n", outfile);
		exit(EXIT_FAILURE);
	}

	int count =0;
	for (int i=0; i<aryLen; i++){
		Node *toPrint = ary[i].head;
		if (toPrint == NULL){
			break;
		}
		int size = ary[i].size;
		if (size >= 2){
			for (int j=0; j<size; j++){
				if (j ==0 && count != 0) fprintf(fp, "\n");
				count += 1;
			 	fprintf(fp, "%s ", toPrint->text);
				if (toPrint->next != NULL){
					toPrint = toPrint->next;
				}
			}
		}
	}

	fclose(fp);
}

/************************************************************************
 * Releases memory allocated for the array and all the linked lists.	*
 * This involves releasing the memory allocated for each Node of each	*
 * linked list and the array itself. Before freeing up memory of a Node *
 * object, make sure to release the memory allocated for the 			*
 * "text" field of that node first.										*
 ************************************************************************/
void freeAnagramArray(AryElement *ary, int aryLen)
{
	Node *ptr, *tmp;
	for (int i = 0; i < aryLen; i++) {
		if (ary[i].size > 0) {
			ptr = ary[i].head;
			while (ptr != NULL) {
				free(ptr->text);
				tmp = ptr->next;
				free(ptr);
				ptr = tmp;
			}
		}
	}
	free(ary);
}

/************************************************************************
 * Allocates memory for a Node object and initializes the "text" field	*
 * with the input string/word and the "next" field to NULL. Returns a	*
 * pointer to the Node object created.									*
 ************************************************************************/
Node *createNode(char *word)
{
	Node *node = NULL;
	node = malloc(sizeof(Node));
	node->text = malloc(sizeof(char)*MAX_WORD_SIZE);
	strcpy(node->text, word); //make a copy of word to save in
	node->next = NULL;
	return node;
}

/************************************************************************
 * Returns true if the input strings are anagrams, false otherwise.		*
 * Assumes the words contain only lower case letters.					*
 ************************************************************************/
bool areAnagrams(char *word1, char *word2)
{
	//create int array of size 26
	int wordScore[26] = {0};

	//words must be equal to be anagrams
	if (sizeof(word1) != sizeof(word2)){
		return false;
	}

	//For each word, find the index of that word then subtracts if exist
	for (int i=0; i<strlen(word1); i++){
		int index = toupper(word1[i]) - 65;
		wordScore[index] += 1;
	}
	//For other word, add if exists, end result should be zero
	for (int i=0; i<strlen(word2); i++){
		int index = toupper(word2[i]) - 65;
		wordScore[index] -= 1;
	}

	for (int i=0; i<26; i++){
		if (wordScore[i] != 0){
			return false;
		}
	}

	return true;
}
