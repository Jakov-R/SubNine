import { Athlete } from '../athlete';

export interface AthleteListRequest {
    success: boolean;
    response: Athlete[];
}