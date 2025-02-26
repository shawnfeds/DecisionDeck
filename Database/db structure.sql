-- Creating the DecisionDeck database
CREATE DATABASE DecisionDeck;
GO

-- Using the DecisionDeck database
USE DecisionDeck;
GO

-- Creating the Roles table first because Users table depends on it
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY,
    RoleName NVARCHAR(50) NOT NULL
);

-- Creating the Groups table next, as Users will now depend on Groups
CREATE TABLE Groups (
    GroupID INT PRIMARY KEY IDENTITY,
    GroupName NVARCHAR(100) NOT NULL,
    CreatedDate DATETIME NOT NULL
);

-- Creating the Users table next since it depends on Groups and Roles
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    RoleID INT,
    GroupID INT,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
);

-- Creating the Polls table next, as it now has dependencies on Groups
CREATE TABLE Polls (
    PollID INT PRIMARY KEY IDENTITY,
    PollName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME NOT NULL,
    PollEndDate DATETIME NOT NULL,
    GroupID INT,
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
);

-- Creating the PollOptions table next, as it depends on Polls
CREATE TABLE PollOptions (
    PollOptionID INT PRIMARY KEY IDENTITY,
    PollID INT,
    OptionName NVARCHAR(100) NOT NULL,
    SelectedCount INT DEFAULT 0,
    FOREIGN KEY (PollID) REFERENCES Polls(PollID)
);

-- Creating the AlreadyVoted table next, as it depends on Polls and Users
CREATE TABLE AlreadyVoted (
    AlreadyVotedID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    PollID INT NOT NULL,
    UNIQUE (UserID, PollID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (PollID) REFERENCES Polls(PollID)
);

