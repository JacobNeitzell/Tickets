-- Active: 1678299152493@@SG-copy-bugle-5822-7314-mysql-master.servers.mongodirector.com@3306@Tickets

CREATE TABLE
    IF NOT EXISTS usertickets(
        id INT NOT NULL AUTO_INCREMENT primary key,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        ticketlist INT NOT NULL,
        ticketId INT NOT NULL,
        FOREIGN KEY (ticketId) REFERENCES tickets (id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';