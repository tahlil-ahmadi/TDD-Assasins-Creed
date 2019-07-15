Feature: Charter Schedule Feature
	In order to ?
	As a ?
	I want to be ?

Scenario: Defining Charter Schedule
	Given 'Ali' is a flight agency manager
	And he has entered the following charter schedule
	| FlightNo | Seats | Airplane   | Airline |
	| WK-550   | 120   | Airbus-320 | Mahan   |
	And He has assigned the following timetable to it
	| DayOfWeek | Origin | Destination | DepartureTime | ArriveDate |
	| Monday    | IKA    | DXB         | 08:00         | 09:30      |
	| Wednesday | DXB    | IKA         | 17:00         | 18:30      |
	When he submits the charter schedule
	Then it should be appear in the list of charter schedules