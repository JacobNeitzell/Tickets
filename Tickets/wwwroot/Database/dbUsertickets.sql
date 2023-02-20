-- Active: 1675287303490@@SG-south-front-8653-7173-mysql-master.servers.mongodirector.com@3306@Sgroot

CREATE TABLE
    IF NOT EXISTS usertickets(
        id INT NOT NULL AUTO_INCREMENT primary key,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        ticketlist INT NOT NULL,
        ticketId INT NOT NULL,
        FOREIGN KEY (ticketId) REFERENCES tickets(ticketId) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';