Feature: FlightGeneration
	In order to generate flights easily and time-efficient
	As a flight agency manager
	I want to generate flights from charter schedule in a batch manner

Scenario: Generate flights
	Given 'Ali' is a flight agency manager
	And He has defined a charter schedule as following
	| FlightNo | Seats | Airplane   | Airline |
	| WK-550   | 120   | Airbus-320 | Mahan   |
	And He has assigned the following timetable to it
	| DayOfWeek | Origin | Destination | DepartureTime | ArriveDate |
	| Monday    | IKA    | DXB         | 08:00         | 09:30      |
	| Wednesday | DXB    | IKA         | 17:00         | 18:30      |
	When he try to generate flights in range 
	| Begin                | End               |
	| 2020-01-01 Wednesday | 2020-01-10 Friday |
	Then the following flights should be generated 
	| FlightNo | Departure        | Arrive           | Origin | Destination | Seats |
	| WK-550   | 2020-01-01 17:00 | 2020-01-01 18:30 | DXB    | IKA         | 120   |
	| WK-550   | 2020-01-06 08:00 | 2020-01-06 09:30 | IKA    | DXB         | 120   |
	| WK-550   | 2020-01-08 17:00 | 2020-01-08 18:30 | DXB    | IKA         | 120   |

