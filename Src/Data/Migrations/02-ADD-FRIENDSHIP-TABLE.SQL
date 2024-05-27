CREATE TABLE `concord`.`friendships` (
    `id`          BIGINT NOT NULL AUTO_INCREMENT,
    `sender_id`        BIGINT NOT NULL,
    `recipient_id`       BIGINT NOT NULL,
    `status`  VARCHAR(1) NOT NULL,
    `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP NULL ON UPDATE CURRENT_TIMESTAMP,
    `accepted_at` TIMESTAMP,
    `deleted_at` TIMESTAMP,
    PRIMARY KEY (`id`),
    FOREIGN KEY (`sender_id`) REFERENCES users(id),
    FOREIGN KEY (`recipient_id`) REFERENCES users(id)
);
