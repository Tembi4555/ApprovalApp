import Button from "./Button/Button";
import DynamicOptionUsers from "./DynamicOptionUsers";
import Modal from "./Modal/Modal";
import { useEffect, useState, useCallback } from "react";

export default function EffectSection() {
    const [modal, setModal] = useState(false);
    const [loading, setLoading] = useState(false);
    const [tickets, setTickets] = useState([]);

    const fetchTicketsByPersonId = useCallback(async () => {
        setLoading(true);
        const response = await fetch('http://localhost:5041/api/Tickets/outgoing/1');
        const tickets = await response.json();
        setTickets(tickets);
        setLoading(false);
    }, [])

    useEffect(() => {
        fetchTicketsByPersonId();
    }, [fetchTicketsByPersonId])

    return (
        <section>
            <h3>
                Effects
            </h3>
            <Button style={{marginBottom: "1rem"}} onClick={() => setModal(true)}>
                Открыть информацию
            </Button>
            <Modal open={modal}>
                <h3>Выберите пользователя</h3>
                <DynamicOptionUsers />
                <Button onClick={() => setModal(false)}>
                    Закрыть
                </Button>
            </Modal>

            {loading && <p>Загрузка...</p>}
            {!loading && 
                <ul>
                    {tickets.map((ticket) => (<li key={ticket.id}>Тема: {ticket.title}. Описание: {ticket.description}. Статус: {ticket.status}</li>))}
                </ul>
            }

            <DynamicOptionUsers />


            
        </section>
    )
}