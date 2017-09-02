"""Module represents example of implementation of snapsack problem"""

class Thing(object):
    """Represents a Thing object that is supposed to be stolen"""
    def __init__(self, name, weight, value):
        self.name = name
        self.weight = weight
        self.value = value

class SolvingGridCell(object):
    """Represents a cell for solving grid. Contains info about things sroted and current value
    (sum of values of things)
    """
    def __init__(self):
        self.things = []
        self.value = int()


class Stealer(object):
    """Grabs some things and put it to his knapsack"""
    def __init__(self, max_weight):
        self.max_weight = max_weight

    def get_necessary_things(self, available_things):
        """Finds the best suit to steel"""
        #Creates a grid where info about current subproblem solution will be stored
        #Each cell - specially prepared object SolvingGridCell
        solving_grid = [[SolvingGridCell() for x in range(self.max_weight)] for y in range(len(available_things))]
        #For each index of existing thing (for each created list - or for each raw)
        for i in range(len(available_things)):
            #For each index of sizes in our knapsack (for each item in a list - or for each cell)
            for j in range(self.max_weight):
                size = j+1
                #If it is the first thing (raw) - we can't use usual formula
                if i == 0:
                    #If the thing suits to chosen knapsack (our subproblem) we just write it to value of current cell
                    #Otherwise it should be 0 by default
                    if size >= available_things[i].weight:
                        solving_grid[i][j].value = available_things[i].value
                        solving_grid[i][j].things.append(available_things[i])
                else:
                    #If size of current knapsack is more than size of current thing we try to deternine
                    #whether it is better to put this stuff and add somehing else
                    #eather better to leave our previus variant (in case it had more value)
                    if size > available_things[i].weight:
                        #solving_grid[i][j].value = max(solving_grid[i - 1][j].value, available_things[i].value + solving_grid[i - 1][j - available_things[i].weight].value)
                        if solving_grid[i - 1][j].value >= available_things[i].value + solving_grid[i - 1][j - available_things[i].weight].value:
                            solving_grid[i][j].value = solving_grid[i - 1][j].value
                            solving_grid[i][j].things = list(solving_grid[i - 1][j].things)
                        else:
                            solving_grid[i][j].value = available_things[i].value + solving_grid[i - 1][j - available_things[i].weight].value
                            solving_grid[i][j].things = list(solving_grid[i - 1][j - available_things[i].weight].things)
                            solving_grid[i][j].things.append(available_things[i])
                    #Else if the size is the same - we can eather put ONLY current thing inside
                    #eather leave our previus variant (in case it had more value)
                    elif size == available_things[i].weight:
                        #solving_grid[i][j].value = max(solving_grid[i - 1][j].value,available_things[i].value)
                        if solving_grid[i - 1][j].value >= available_things[i].value:
                            solving_grid[i][j].value = solving_grid[i - 1][j].value
                            solving_grid[i][j].things = list(solving_grid[i - 1][j].things)
                        else:
                            solving_grid[i][j].value = available_things[i].value
                            solving_grid[i][j].things.append(available_things[i])
                    #If our current thing does't fit in current-size knapsack - we can't put it inside so we leave previos variant
                    else:
                        solving_grid[i][j].value = solving_grid[i - 1][j].value
                        solving_grid[i][j].things = list(solving_grid[i - 1][j].things)
        return solving_grid

class Program(object):
    """Instead of test - just invoke method that I want to test"""
    def check_stealer(self):
        """Checks if stealer sleals right things"""
        stealer = Stealer(6)
        things = [Thing('W', 3, 10),
                  Thing('B', 1, 3),
                  Thing('F', 2, 9),
                  Thing('J', 2, 5),
                  Thing('C', 1, 6)]

        grid = stealer.get_necessary_things(things)
        for i in range(len(grid)):
            for j in range(len(grid[i])):
                print(grid[i][j].value, end=': ')
                for thing in grid[i][j].things:
                    print(thing.name, end=' ')
                print()

program = Program()
program.check_stealer()