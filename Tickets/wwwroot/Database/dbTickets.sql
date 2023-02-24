-- Active: 1675287303490@@SG-south-front-8653-7173-mysql-master.servers.mongodirector.com@3306@Sgroot

CREATE TABLE
    IF NOT EXISTS tickets(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        ticketname VARCHAR(255) NOT NULL,
        ticketclient VARCHAR(255) NOT NULL,
        description VARCHAR(255) NOT NULL
    ) default charset utf8 COMMENT '';