DROP DATABASE IF EXISTS GALLERY;
CREATE DATABASE GALLERY;
use GALLERY;

CREATE TABLE ARTIST 
  ( 
	ArtistID		INT				NOT NULL,	
	FName    	  	VARCHAR(30)     NOT NULL,
	mInit			CHAR,
    LName    	  	VARCHAR(30)     NOT NULL,
    Phone         	INT,
    DateOfBirth  	DATE,
    StreetAddress	VARCHAR(100),
	ApartmentNumber	VARCHAR(20) 	DEFAULT NULL,
	City			VARCHAR(50),
	State			VARCHAR(25),
	ZipCode			VARCHAR(10),
	ArtStyle      	VARCHAR(15)		    NOT NULL,
  PRIMARY KEY (ArtistID) );
  
CREATE TABLE ARTWORK 
  (Title			VARCHAR(15)		NOT NULL,
   Artist			INT				NOT NULL,
   ArtType			VARCHAR(15)		NOT NULL,
   CreationDate		VARCHAR(50),
   DateAquired		DATE			NOT NULL,
   Price			INT				NOT NULL,
   Location			VARCHAR(15)		NOT NULL,
  PRIMARY KEY (Title),
  FOREIGN KEY (Artist) REFERENCES ARTIST(ArtistID) );
  
CREATE TABLE ART_SHOWS 
  ( ShowArtist     	INT     		NOT NULL,
	ShowDate		DATE			NOT NULL,
    Time	      	VARCHAR(15)     NOT NULL,
    Location		VARCHAR(30)		NOT NULL,
    Contact			VARCHAR(30)		NOT NULL,
    ContactPhone	INT				NOT NULL,
	DateOfBirth  	DATE			NOT NULL,
  PRIMARY KEY (ShowArtist),
  UNIQUE(ShowArtist),
  FOREIGN KEY (ShowArtist) REFERENCES ARTIST(ArtistID) );
  
CREATE TABLE CUSTOMER 
  ( CustomerNumber 	INT				NOT NULL,
	CustomerName	VARCHAR(15)		NOT NULL,
    PNumber			INT				NOT NULL,
    ArtPreferences	VARCHAR(15)		NOT NULL,
  PRIMARY KEY (CustomerNumber) );
  
CREATE TABLE INTERESTED_IN 
  ( CustomerNo	 	INT				NOT NULL,
    ArtTitle		VARCHAR(15)		NOT NULL,
  PRIMARY KEY (CustomerNo,ArtTitle),
  FOREIGN KEY (CustomerNo) REFERENCES CUSTOMER(CustomerNumber),
  FOREIGN KEY (ArtTitle) REFERENCES ARTWORK(Title) );
  
  
  
INSERT INTO	ARTIST
	VALUES	('01','John','B','Smith','123456789','1965-01-09','731 Fondren', 'NULL', 'Houston', 'TX','00000','Modern');
    
INSERT INTO	ARTIST
	VALUES	('02','Franklin','T','Wong','333445555','1955-12-08','638 Voss', 'NULL', 'Houston', 'TX','00000','Modern');
    
INSERT INTO	ARTIST
	VALUES	('03','Alicia','J','Zelaya','999887777','1968-01-19','3321 Castle', 'NULL', 'Houston', 'TX','00000','Modern');

INSERT INTO	ARTIST
	VALUES	('04','Jennifer','S','Wallace','987654321','1941-06-20','291 Berry', 'NULL', 'Houston', 'TX','00000','Modern');
    
INSERT INTO	ARTWORK
	VALUES	('Art01','01', 'Modern','2000-11-12','2018-11-12','500','Blue Room');
    
INSERT INTO	ARTWORK
	VALUES	('Art02','02', 'Modern','2000-11-12','2018-11-12','500','Blue Room');
    
INSERT INTO	ARTWORK
	VALUES	('Art03','03', 'Modern','2000-11-12','2018-11-12','500','Blue Room');
    
INSERT INTO	ARTWORK
	VALUES	('Art04','04', 'Modern','2000-11-12','2018-11-12','500','Blue Room');

INSERT INTO	ART_SHOWS
	VALUES	('01','2018-11-15','120000','Blue Room','Gary','714890000','2000-11-12');
    
INSERT INTO	ART_SHOWS
	VALUES	('02','2018-11-15','120000','Blue Room','Gary','714890000','2000-11-12');
    
INSERT INTO	ART_SHOWS
	VALUES	('03','2018-11-15','120000','Blue Room','Gary','714890000','2000-11-12');
    
INSERT INTO	ART_SHOWS
	VALUES	('04','2018-11-15','120000','Blue Room','Gary','714890000','2000-11-12');
    
INSERT INTO	CUSTOMER
	VALUES	('010','Joe','010101011','Contemporary');
    
INSERT INTO	CUSTOMER
	VALUES	('020','Joe2','010101011','Contemporary');
    
INSERT INTO	CUSTOMER
	VALUES	('030','Joe3','010101011','Contemporary');
    
INSERT INTO	CUSTOMER
	VALUES	('040','Joe4','010101011','Contemporary');  
    
INSERT INTO	INTERESTED_IN
	VALUES	('010','Art01');  
    
INSERT INTO	INTERESTED_IN
	VALUES	('020','Art02');  
    
INSERT INTO	INTERESTED_IN
	VALUES	('030','Art03');  
    
INSERT INTO	INTERESTED_IN
	VALUES	('040','Art04');  