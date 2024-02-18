CREATE DATABASE `concord`;
USE `concord`;

CREATE TABLE `concord`.`users` (
    `id`          BIGINT NOT NULL AUTO_INCREMENT,
    `uuid`        VARCHAR(36) NOT NULL UNIQUE,
    `name`       VARCHAR(60) NOT NULL,
    `email`  VARCHAR(60) NOT NULL,
    `password`  VARCHAR(60) NOT NULL,
    `login`  VARCHAR(60) NOT NULL,
    `status`  VARCHAR(1) NOT NULL,
    `profile_picture_url`  VARCHAR(255) NULL,
    `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
	`updated_at` TIMESTAMP NULL ON UPDATE CURRENT_TIMESTAMP,
	`deleted_at` TIMESTAMP,
	PRIMARY KEY (`id`),
	UNIQUE INDEX `uuid_unique` (`uuid` ASC)
);