import { Client } from "./client";

export type NewClient = Omit<Client, "id" | "orders">;