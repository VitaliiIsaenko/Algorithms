"""Example of longest common subsequence algorithm implementation"""
class LongestSubsequenceFinder(object):
    """Solves the problem of finding the length of the longest subsequence"""
    def get_longest_subsequence(self, string1, string2):
        grid = [[0 for j in range(len(string2))] for i in range(len(string1))]
        for i in range(len(string1)):
            for j in range(len(string2)):
                if i == 0 & j == 0:
                    if string1[i] == string2[j]:
                        grid[i][j] = 1
                elif i == 0:
                    if string1[i] == string2[j]:
                        grid[i][j] = 1 + grid[i][j - 1]
                    else:
                        grid[i][j] = grid[i][j - 1]
                else:
                    if string1[i] == string2[j]:
                        grid[i][j] = 1 + grid[i - 1][j - 1]
                    else:
                        grid[i][j] = max([grid[i - 1][j], grid[i][j - 1]])
        return grid[len(string1)-1][len(string2)-1]

longest_substring_finder = LongestSubsequenceFinder()
result = longest_substring_finder.get_longest_subsequence('fosh', 'fish')
print(result)