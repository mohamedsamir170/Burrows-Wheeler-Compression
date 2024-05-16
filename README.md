
# Burrows-Wheeler Transform (BWT) Compression and Decompression

This repository contains the implementation of the Burrows-Wheeler Transform (BWT) compression and decompression algorithm along with Huffman coding and Move-to-Front (MTF) encoding for data compression. This README provides an overview of the functionality, usage, and structure of the code.

## Table of Contents
1. [Introduction](#introduction)
2. [Features](#features)
5. [Algorithm Details](#algorithm-details)
   - [Burrows-Wheeler Transform](#burrows-wheeler-transform)
   - [Burrows-Wheeler Inverse Transform](#burrows-wheeler-inverse-transform)
   - [Move-to-Front Encoding](#move-to-front-encoding)
   - [Move-to-Front Decoding](#move-to-front-decoding)
   - [Huffman Coding](#huffman-coding)
   - [Huffman Decoding](#huffman-decoding)
6. [Complexity Analysis](#complexity-analysis)
7. [Performance](#performance)

## Introduction
The Burrows-Wheeler Transform (BWT) is an algorithm used in data compression and decompression techniques. Combined with Move-to-Front (MTF) encoding and Huffman coding, it provides an efficient way to compress and decompress data. This project implements these algorithms in a structured manner.

## Features
- **Burrows-Wheeler Transform:** Efficiently transforms data to be more compressible and reverses the transformation for decompression.
- **Move-to-Front Encoding:** Encodes data by moving frequently used characters to the front and decodes to recover the original order.
- **Huffman Coding:** Compresses data based on character frequencies and decompresses to restore the original data.
- **Inverse Transformations:** Supports both compression and decompression to fully recover the original data.

## Algorithm Details

### Burrows-Wheeler Transform

The BWT rearranges the input data to make it more amenable to compression and can be reversed to decompress the data. It uses a suffix array to sort all cyclic rotations of the input and then derives the BWT from this sorted order.

**Key Steps**:

1.  Append an End-of-File (EOF) character to the input.
2.  Convert the input to a format suitable for suffix array construction.
3.  Construct the suffix array using the SA-ISA Algorithm.
4.  Generate the BWT using the suffix array.

### Burrows-Wheeler Inverse Transform
The inverse BWT reconstructs the original data from the transformed data.

**Key Steps**:

1.  Construct a dictionary to count the occurrences of each byte in the transformed data.
2.  Build the "first column" by iterating through the count dictionary and adding each byte based on its frequency.
3.  Create a dictionary to store queues for each byte, representing the next position where that byte appears in the transformed data.
4.  Populate the next array based on the order of bytes in the transformed data and the nextIndex dictionary.
5.  Iteratively use the next array to reconstruct the original byte sequence, starting from the first byte in the "first column".
6.  Remove the appended EOF character during reconstruction.

### Move-to-Front Encoding

MTF encoding transforms the input data to make it more suitable for compression by moving frequently used characters to the front and can be reversed to decode the data.

**Key Steps**:

1.  Initialize a table of all possible byte values.
2.  For each byte in the input, find its index in the table and move it to the front.

### Move-to-Front Decoding

MTF decoding reverses the encoding process to recover the original data order.

**Key Steps**:

1.  Initialize a table of all possible byte values.
2.  For each encoded byte, use its index to retrieve the corresponding value from the table.
3.  Move the retrieved value to the front of the table.

### Huffman Coding

Huffman coding compresses data by assigning shorter codes to more frequent characters and decompresses the data by reversing this process.

**Key Steps**:

1.  Build a frequency map of the input characters.
2.  Construct a Huffman tree based on character frequencies.
3.  Generate binary codes for each character.
4.  Encode the input data using the generated codes.

### Huffman Decoding

Huffman decoding reconstructs the original data from the compressed bit stream.

**Key Steps**:

1.  Reconstruct the Huffman tree from the encoded data.
2.  Traverse the Huffman tree to decode the bit stream back into the original data.

## Complexity Analysis

### Burrows-Wheeler Transform

-   **Time Complexity**: O(n)
-   **Space Complexity**: O(n)

### Burrows-Wheeler Inverse Transform

-   **Time Complexity**: O(n)
-   **Space Complexity**: O(n)

### Move-to-Front Encoding

-   **Time Complexity**: O(n)
-   **Space Complexity**: O(n)

### Move-to-Front Decoding

-   **Time Complexity**: O(n)
-   **Space Complexity**: O(n)

### Huffman Coding

-   **Time Complexity**: O(n log m), where `m` is the number of unique characters.
-   **Space Complexity**: O(n + m)

### Huffman Decoding

-   **Time Complexity**: O(n + m)
-   **Space Complexity**: O(n + m)

## Performance

-   **Compression Ratio**: 37%
