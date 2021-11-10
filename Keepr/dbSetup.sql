CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE Table IF NOT EXISTS keeps(
id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
creatorId VARCHAR(255) NOT NULL COMMENT 'creator Id',
name VARCHAR(255) COMMENT 'keep name',
description VARCHAR(255) COMMENT 'keep description',
img VARCHAR(255) COMMENT 'keep picture',
shares int NOT NULL,
keeps int NOT NULL,
FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE Table IF NOT EXISTS vaults(
id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
creatorId VARCHAR(255) NOT NULL COMMENT 'creator Id',
name VARCHAR(255) COMMENT 'keep name',
description VARCHAR(255) COMMENT 'keep description',
isPrivate TINYINT,
FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE Table IF NOT EXISTS vaultkeeps(
id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
creatorId VARCHAR(255) NOT NULL COMMENT 'creator Id',
vaultId int NOT NULL,
keepId int NOT NULL,
FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

ALTER TABLE vaults ADD COLUMN img VARCHAR(255);

-- https://images.unsplash.com/photo-1507499739999-097706ad8914?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=389&q=80

-- https://images.unsplash.com/photo-1462332420958-a05d1e002413?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1807&q=80

-- https://images.unsplash.com/photo-1446941611757-91d2c3bd3d45?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=502&q=80

-- https://images.unsplash.com/photo-1496715976403-7e36dc43f17b?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1170&q=80

-- https://images.unsplash.com/photo-1532798369041-b33eb576ef16?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=465&q=80

UPDATE keeps
SET
img = "https://images.unsplash.com/photo-1532798369041-b33eb576ef16?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=465&q=80"
WHERE id > 992;

SELECT * FROM keeps;








