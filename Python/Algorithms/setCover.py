class RadiostationsCreator:
    """The class generates dummy data to work with"""
    def get_stations():
        """Generates stations and states they cover"""
        stations = {}
        stations['kone'] = set(['id', 'nv', 'ut'])
        stations['ktwo'] = set(['wa', 'id', 'mt'])
        stations['kthree'] = set(['or', 'nv', 'ca'])
        stations['kfour'] = set(['nv', 'ut'])
        stations['kfive'] = set(['ca', 'az'])
        return stations

class OptimalRadiostationsGetter():
    states_needed = set(['mt', 'wa', 'or', 'id', 'nv', 'ut', 'ca', 'az'])
    final_stations = set()

    #Пока еще остались не покрытые станции
    while states_needed:
        best_station = None
        states_covered_by_current_best = set()
        stations = RadiostationsCreator.get_stations()
        #In the loop we try to understand what station is the best for the moment
        for station, states_for_station in stations.items():
            #covered contains intersection of states that we STILL need to cover
            covered = states_needed & states_for_station
            #Here we check if current station better than previously checked (if it covers more than previous)
            if len(covered) > len(states_covered_by_current_best):
                best_station = station
                states_covered_by_current_best = covered
            final_stations.add(best_station)
            states_needed -= states_covered_by_current_best
    print(final_stations)