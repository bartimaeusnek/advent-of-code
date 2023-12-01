#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>

int isNumeric(char c) {
    return c >= '0' && c <= '9';
}

int main() {
    FILE *file = fopen("input", "r");
    fseek(file, 0, SEEK_END);
    long size = ftell(file);
    fseek(file, 0, SEEK_SET);

    char *mem = malloc(size);
    fread(mem, 1, size, file);

    int j = 0;
    char read = 0;

    int max = 0;

    while(j < size) {
        char number[3] = {-1, -1, '\0'};
        while(read != '\n' && j < size) {
            read = mem[j++];
            if (number[0] == -1 && isNumeric(read)) {
                number[0] = read;
            }
        }
        int pos = j;
        while(1) {
            read = mem[--j];
            if (isNumeric(read)) {
                number[1] = read;
                break;
            }
        }
        j = pos;

        int num = atoi(number);
        max += num;
    }

    printf("Sum: %i\n", max);
    free(mem);
    return 0;
}

