import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

const ProfilePage = () => {
    const { user, isAuthenticated, isLoading } = useAuth0();

    if (isLoading) {
        return <div>Loading...</div>;
    }

    return (
        <div >
            {isAuthenticated && (
                <div >
                    <h2>User Profile</h2>
                    <img src={user.picture} alt={user.name} />
                    <p>Name: {user.name}</p>
                    <p>Email: {user.email}</p>
                </div>
            )}
        </div>
    );
}
export default ProfilePage;