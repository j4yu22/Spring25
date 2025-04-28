# merge sort test

def merge_sort(arr):
    """
    Recursively sorts a list in ascending order using a functional-style Merge Sort.

    Parameters:
        arr (list of numbers): The list to sort.

    Returns:
        list: A new sorted list containing the elements of 'arr'.
    """
    if len(arr) <= 1:
        return arr

    mid = len(arr) // 2
    left = merge_sort(arr[:mid])
    right = merge_sort(arr[mid:])
    return merge(left, right)
    


def merge(left, right):
    """
    Merges two sorted lists into a single sorted list without modifying the originals.

    Parameters:
        left (list of numbers): A sorted list.
        right (list of numbers): Another sorted list.

    Returns:
        list: A new merged and sorted list.
    """
    if not left:
        return right
    if not right:
        return left
    
    if left[0] <= right[0]:
        return [left[0]] + merge(left[1:], right)
    else:
        return [right[0]] + merge(left, right[1:])


nums = [38, 5, 17, 9, 4, 40, 34, 21, 4, 10, 13]
sorted_nums = merge_sort(nums)
print(sorted_nums)
