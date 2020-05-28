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
  "ContractName" TEXT,
  "ContractPhoneNumber" TEXT
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
  ( "Name", "CountryOfOrign", "NumberOfMemebers", "Website", "Style", "IsSigned", "ContractName", "ContractPhoneNumber")
VALUES
  ()