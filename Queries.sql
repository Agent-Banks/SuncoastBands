--1.

CREATE TABLE "BANDS"
(
  "Id" SERIAL PRIMARY KEY,
  "Name" TEXT NOT NULL,
  "CountryOfOrign" TEXT,
  "NumberOfMemebers" INT,
  "Website" TEXT,
  "Style" TEXT,
  "IsSigned" BOOLEAN,
  "ContactName" TEXT,
  "ContactPhoneNumber" TEXT
)

CREATE TABLE "Albums"
(
  "Id" SERIAL PRIMARY KEY,
  "BandId" INTEGER REFERENCES "BANDS" ("Id"),
  "Title" TEXT NOT NULL,
  "IsExplicit" BOOLEAN,
  "ReleaseDate" TIMESTAMP,
)

--2. 

INSERT INTO "BANDS"
  ( "Name", "CountryOfOrign", "NumberOfMemebers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES
  ('Led Zeppelin', 'United Kingdom', "4", 'ledzeppelin.com', 'Rock', 'True', 'Bill', '727-765-0978');

--3. 

SELECT *
FROM "BANDS";

--4.

INSERT INTO "Albums"
  ("BandId", "Title", "IsExplicit", "ReleaseDate")
VALUES
  ('1', 'Houses of The Holy', 'False', '1973-03-28 12:00:00');


--5. 

UPDATE "Bands" SET "IsSigned" = 'False' WHERE "Name" = 'Led Zeppelin';

--6.

UPDATE "Bands" SET "IsSigned" = 'True' WHERE "Name" = 'Led Zeppelin';

--7. 
