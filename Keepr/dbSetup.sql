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








