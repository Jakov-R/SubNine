import { Club } from '../club';

export interface ClubListRequest {
    success: boolean;
    response: Club[];
}