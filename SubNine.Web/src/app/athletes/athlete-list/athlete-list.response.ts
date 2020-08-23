import { Athlete } from "../athlete";

export interface AthleteListResponse {
    success: boolean;
    athletes: Athlete[];
    count: number;
    perPage: number;
    page: number;
}