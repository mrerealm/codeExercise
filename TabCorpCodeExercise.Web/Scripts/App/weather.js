var myApp = angular.module('weatherApp', []);

var windDirectionTable = ['N', 'NNE', 'NE', 'ENE', 'E', 'ESE', 'SE', 'SSE', 'S', 'SSW', 'SW', 'WSW', 'W', 'WNW', 'NW', 'NNW', 'N'];

function convertLongToHour (long) { // Earth Longitude to local Hour
    if (isNaN(long)) return '?';
    var val = long < 0 ? 360 + long : long;
    var delta = Math.round((val * 4) / 60);
    delta = delta > 0 ? delta : 0;
    delta += delta === 10 ? 1 : 0; // daylight savings
    var now = new Date();
    var hour = now.getUTCHours() + delta; // GMT time
    return hour % 23;
}

function convertMpsKph(val) { // Wind direction in degrees to Compass 'N S W E' combination
    if (isNaN(val)) return '?';
    return Math.round(val * 3.6);
}

function convertToCompass (val) { // Map to a Compass direction 
    if (isNaN(val)) return '?';
    var index = Math.round(Math.round(val % 360) / 22.5) + 1 - 1; // zero index
    return (index >= 0 && index < windDirectionTable.length) ? windDirectionTable[index] : '?';
}

function convertKToCelsius (val) { // Kelvin to C
    if (isNaN(val)) return '?';
    return Math.round(val - 273.15)
}

function calculateDewPoint (temp, humid) { // temp in Kelvin, humidity in %
    if (isNaN(temp) || isNaN(humid)) return '?';
    return Math.round(temp - (100 - humid) / 5 - 273.15) + 1;
}


function weather(country, city, long, windSpeed, windDir, visibility, skycond, temp, dewpt, humidity, pressure, icon) {
    var now = new Date();
    var min = now.getMinutes();
    this.country = country;
    this.city = city;
    this.hour = convertLongToHour(long);
    this.windSpeed = convertMpsKph(windSpeed);
    this.windDir = convertToCompass(windDir);
    this.visibility = visibility > 1000 ? visibility / 1000 : visibility > 100 ? visibility / 100 : visibility / 10;
    this.sky = skycond;
    this.temperature = convertKToCelsius(temp);
    this.humidity = humidity;
    this.dewpt = calculateDewPoint(temp, humidity);
    this.pressure = pressure;
    this.icon = 'http://openweathermap.org/img/w/' + icon + '.png';
    this.day = this.hour > 6 && this.hour < 19;
    this.time = (this.hour >= 13? this.hour % 12 : this.hour) + ':' + (min < 10 ? '0' : '') + min + ((this.hour >= 13) ? 'PM' : 'AM');

}

myApp.controller('weatherCtrl', function ($scope, $http) {

    $scope.country = 'Australia';
    $scope.city = 'Sydney';
    $scope.cities = [];
    $scope.weather = null;
    $scope.errors = '';
    $scope.introMsg = 'Loading weather details ...';

    $scope.init = function (country, city) {
        $scope.country = country;
        $scope.city = city;
    }

    $scope.getCities = function (country) {
        $http.get('/api/country/'+country)
            .then(function success(result) {
                $scope.errors = '';
                if (result.status === 200) {
                    $scope.cities = result.data;
                    $scope.city = (country === 'Australia')? 'Sydney' : $scope.cities[0];
                    $scope.getWeather($scope.country, $scope.city);
                }
                else {
                    $scope.introMsg = 'Unable to get weather details';
                    $scope.cities = [];
                    $scope.errors = result.statusText;
                }
            }, function error(response) {
                $scope.introMsg = 'Unable to get weather details';
                $scope.weather = null;
                $scope.errors = response.data.Message ? response.data.Message : response.statusText;
            });
    };

    $scope.getWeather = function (country, city) {
        $scope.introMsg = 'Unable to get weather details';
        $http.get('/api/weather/' + country + '/' + city)
            .then(function success(result) {
                $scope.errors = '';
                $scope.weather = null;
                if (result.status === 200) {
                    var data = result.data;
                    if (data) {
                        $scope.weather = new weather(country, city,
                            data.Coord.Lon,
                            data.Wind.Speed,
                            data.Wind.Deg,
                            data.Visibility,
                            data.Weather[0].Description,
                            data.Main.Temp,
                            0,
                            data.Main.Humidity,
                            data.Main.Pressure,
                            data.Weather[0].Icon);
                    }
                }
                else {
                    $scope.introMsg = 'Unable to get weather details';
                    $scope.weather = null;
                    $scope.errors = result.statusText;
                }
            }, function error(response) {
                $scope.introMsg = 'Unable to get weather details';
                $scope.weather = null;
                $scope.errors = response.data.Message ? response.data.Message : response.statusText;
            });
    };

    $scope.getCities($scope.country);
});