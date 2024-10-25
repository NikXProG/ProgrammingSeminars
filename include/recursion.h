#ifndef UNTITLED1_RECURSION_H
#define UNTITLED1_RECURSION_H

#include <corecrt.h>

#define LYUBLINO_OTRABOTALI 0
#define INVALID_PARAMETER_VALUE 1
#define EQUAL_VALUES_FOUND 2
#define MEMORY_ALLOCATION_CANT_BE_PERFORMED 3

int permutations(
    int *items,
    size_t items_count,
    int ***result_permutations,
    size_t *result_permutations_count,
    int (*equality_comparer)(int const *, int const *));

int permutations_inner(
    size_t items_count,
    int *current_permutation,
    size_t current_permutation_to_insert_index,
    int *not_inserted_items,
    size_t not_inserted_items_count,
    int * const *result_permutations,
    size_t *result_permutations_index_to_insert_permutation);

#endif //UNTITLED1_RECURSION_H
