


CREATE TABLE CustomerInfo
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Did INT REFERENCES District (Id),
Code VARCHAR(50),
Name VARCHAR(100),
Address VARCHAR(300),
Contact VARCHAR(50),
)

CREATE TABLE District
(
Id INT IDENTITY(1,1) PRIMARY KEY,
District VARCHAR(100),
)


SELECT * FROM CustomerInfo

SELECT * FROM District

DROP TABLE CustomerInfo


INSERT INTO  District(District)VALUES ('narayangonj')
INSERT INTO  District(District)VALUES ('dhaka')
INSERT INTO  District(District)VALUES ('comilla')

INSERT INTO CustomerInfo (Code,Did,Name,Address,Contact)  VALUES ('ab15',1,'jumann', 'fatulla' ,'01311369369')
INSERT INTO CustomerInfo (Code,Did,Name,Address,Contact)  VALUES ('a02',2,'kalam', 'mirpur' ,'015555555555')
INSERT INTO CustomerInfo (Code,Did,Name,Address,Contact)  VALUES ('a03',3,'Helim', 'Miabazar' ,'0199999999')

INSERT INTO CustomerInfo VALUES ('Hasan', 'Sylhet' ,'01711369369')
INSERT INTO CustomerInfo VALUES ('Rafi', 'BNorisal' ,'01811369369')