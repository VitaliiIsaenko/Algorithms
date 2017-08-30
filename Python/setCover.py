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

class OptimalRadiotrationsGetter():
    states_needed = set(['mt', 'wa', 'or', 'id', 'nv', 'ut', 'ca', 'az'])
    final_stations = set()

    best_station = None
    states_coveres = set()
    stations = RadiostationsCreator.get_stations()
    for station, states_for_station in stations.items():
        print(station)
        print(states_for_station)