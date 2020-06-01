--1.

CREATE TABLE "Bands"
(
  "Id" SERIAL PRIMARY KEY,
  "Name" TEXT NOT NULL,
  "CountryOfOrign" TEXT,
  "NumberOfMembers" INT,
  "Website" TEXT,
  "Style" TEXT,
  "IsSigned" BOOLEAN,
  "ContactName" TEXT,
  "ContactPhoneNumber" TEXT
);

CREATE TABLE "Albums"
(
  "Id" SERIAL PRIMARY KEY,
  "BandId" INTEGER REFERENCES "Bands" ("Id"),
  "Title" TEXT NOT NULL,
  "IsExplicit" BOOLEAN,
  "ReleaseDate" DATE
);

--2. 

INSERT INTO "Bands"
  ( "Name", "CountryOfOrign", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES
  ('Led Zeppelin', 'United Kingdom', '4', 'ledzeppelin.com', 'Rock', 'True', 'Bill', '727-765-0978');

--3. 

SELECT *
FROM "Bands";

--4.

INSERT INTO "Albums"
  ("BandId", "Title", "IsExplicit", "ReleaseDate")
VALUES
  ('1', 'Houses of The Holy', 'False', '1973-03-28');


--5. 

UPDATE "Bands" SET "IsSigned" = 'False' WHERE "Name" = 'Led Zeppelin';

--6.

UPDATE "Bands" SET "IsSigned" = 'True' WHERE "Name" = 'Led Zeppelin';

--7. 
--Select "Employees"."FullName", "Departments"."Id"
--From "Employees"
--Join "Departments" ON "Employees"."DepartmentId" = "Departments"."Id";

SELECT "Albums"."Title", "Bands"."Name"
FROM "Albums"
  JOIN "Bands" ON "Albums"."BandId" = "Bands"."Id";

--8.

Select *
FROM "Albums"
ORDER BY "Albums"."ReleaseDate";

--9.

SELECT *
FROM "Bands"
WHERE  "IsSigned" = 'True';

--10.

SELECT *
FROM "Bands"
WHERE  "IsSigned" = 'False';
