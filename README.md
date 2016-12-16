# Project Title

#### Description, Date.

#### By **Steve Burton**

### Specifications
This project will create an app to allow users to track bands and the venues where they've played concerts.

These are the steps I'll take to write my code:

One I'll test to ensure the database is empty to begin with.
* Input: 0
* Output: 0

Two I'll check for equality if bands or venues are the same.
* Input: "Mighty Mighty Bosstones"
* Output: "Mighty Mighty Bosstones"

Three, test to ensure the user can save to the database.
* Input: "Mighty Mighty Bosstones"
* Output: "Mighty Mighty Bosstones"

Four, test to ensure an ID is assigned to a band.
* Input: 1
* Output: 1

Five, test that a user can find a band in the database by ID
* Input: Band ID
* Output: "Mighty Mighty Bosstones"

Six, write, in order, the same tests for a venue.
* Input: "Wonder Ballroom"
* Output: "Wonder Ballroom"

Seven, test to update venue.
* Input: "Wonder Ballroom"
* Output: "Wonder Dancehall"

Eight, test to delete a venue.
* Input: "Wonder Ballroom"
* Output: Empty

Nine, test to add bands to a venue.
* Input: "Mighty Mighty Bosstones"
* Output: "Wonder Ballroom"

Ten, test to add venues to a band.
* Input: "Wonder Ballroom"
* Output: "Mighty Mighty Bosstones"

Eleven, test to see all the bands that have played at a venue.
* Input: "Wonder Ballroom"
* Output: "Mighty Mighty Bosstones", "Billy Bragg", "The Decemberists"

Twelve, test to see all the venues a band has played at.
* Input: "Mighty Mighty Bosstones"
* Output: "Wonder Ballroom", "Crystal Ballroom"


## Setup/Installation Requirements

Set up a database:
* CREATE DATABASE band_tracker;
* GO
* USE band_tracker;
* GO
* CREATE TABLE bands (id INT IDENTITY(1,1), band_name VARCHAR(255);
* CREATE TABLE venues (id INT IDENTITY(1,1), venue_name VARCHAR(255);
* CREATE TABLE bands_venues (id INT IDENTITY(1,1), band_id INT, venue_id INT);
* GO

* Clone this repository or download it to your computer.
* Navigate to the project directory in the terminal.
* Use the command > dnu restore to download any necessary dependencies.
* Use the command > dnx kestrel to run the project on the local server.
* Navigate to localhost:5004 in your browser to view the app

## Known Bugs

None.

## Support and contact details

You can contact me on Github at steve-burton.

## Technologies Used

HTML, CSS, Bootstrap, C#

### License

GPL

Copyright (c) 2016 **_Steve Burton_**
