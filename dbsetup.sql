-- CREATE TABLE contractors (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   rate INT NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--       REFERENCES profiles3(id)
--       ON DELETE CASCADE
-- )

-- CREATE TABLE jobs (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   location VARCHAR(255) NOT NULL,
--   budget INT NOT NULL,
--   creatorId VARCHAR(255),
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--       REFERENCES profiles3(id)
--       ON DELETE CASCADE
--   )

-- CREATE TABLE contractorjob(
--   id INT NOT NULL AUTO_INCREMENT,   
--   jobId INT,
--   contractorId INT,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (jobId)
--   REFERENCES jobs (id)
--   ON DELETE CASCADE,

--   FOREIGN KEY (contractorId)
--   REFERENCES contractors (id)
--   ON DELETE CASCADE,

--    FOREIGN KEY (creatorId)
--         REFERENCES profiles3(id)
--         ON DELETE CASCADE
-- )

-- CREATE TABLE profiles3 (
--     id VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )