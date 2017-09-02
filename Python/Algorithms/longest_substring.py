"""An example of longest substring finding algorithm implementation"""
class GridCell(object):
     """Represents solving grid cell"""
     def __init__(self):
        self.current_length = 0
        self.common_string = ""

class LongestSubstringFinder(object):
    """Has method that can fing longest substring"""
    def find_longest_subsring(self, string1, string2):
        """Finds maximum length of substring"""
        grid = [[GridCell() for j in range(len(string2))] for i in range(len(string1))]
        for i in range(len(grid)):
            for j in range(len(grid[i])):
                if string1[i] == string2[j]:
                    grid[i][j].current_length = grid[i-1][j-1].current_length
                    grid[i][j].current_length += 1
                    grid[i][j].common_string = ''.join([grid[i-1][j-1].common_string, string2[j]])

        return self.get_cell_with_longest_substring(grid)

    def get_cell_with_longest_substring(self, grid):
        """Get a cell with answer from grid"""
        max = GridCell()
        for i in range(len(grid)):
            for j in range(len(grid[i])):
                if grid[i][j].current_length > max.current_length:
                    max = grid[i][j]
        return max

class Program(object):
    """Tests algorithm"""
    def test(self):
        """Tests algorithm"""
        first_string = 'hish'
        second_string = 'fish'
        substring_finder = LongestSubstringFinder()
        answer_cell = substring_finder.find_longest_subsring(first_string,second_string)
        print('The longest substring length: ' + str(answer_cell.current_length))
        print('The longest substring: ' + answer_cell.common_string)

program = Program()
program.test()
