ALTER TABLE Polls
ADD UserId INT;

ALTER TABLE Polls
ADD CONSTRAINT FK_Polls_User
FOREIGN KEY (UserId) REFERENCES Users(UserId);
