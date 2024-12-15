import { useEffect, useState } from "react"

export default function DynamicOptionUsers() {
    const[users, setUsers] = useState([])

    useEffect(() => {

        fetch("http://localhost:5041/api/Login").then((data) => data.json()).then((val) => setUsers(val))
    }, [])

    return (
        <div>
            <select 
                id="reason" 
                className="control" 
            >
                {
                    users.map((user,i)=><option key={user.id} value={user.id}>{user.userName}</option>)
                }
            </select>
        </div>
    )
}