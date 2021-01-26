import React, { createContext, useState} from 'react';

export const UserContext = createContext();

const UserContextProvider = ({ children }) => {
    // eslint-disable-next-line
    const [user, setUser] = useState(null);

    const saveUser = newUser => {
        setUser(newUser)
    }
        
    return (
        <UserContext.Provider value={{user, saveUser}}>
            {children}
        </UserContext.Provider>
    )
}

export default UserContextProvider;