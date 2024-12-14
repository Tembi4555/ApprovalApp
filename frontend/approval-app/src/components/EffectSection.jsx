import Button from "./Button/Button";
import Modal from "./Modal/Modal";
import { useEffect, useState } from "react";

export default function EffectSection() {
    const [modal, setModal] = useState(false);
    const [loading, setLoading] = useState(false);
    const [tickets, setTickets] = useState([]);


    async function fetchTicketsByPersonId() {
        setLoading(true);
        const response = await fetch('http://localhost:5041/api/Tickets/outcomingtickets/1');
        const tickets = await response.json();
        setTickets(tickets);
        setLoading(false);
    }

    useEffect(() => {
        fetchTicketsByPersonId();
    }, [])

    return (
        <section>
            <h3>
                Effects
            </h3>
            <Button onClick={() => setModal(true)}>
                Открыть информацию
            </Button>
            <Modal open={modal}>
                <h3>Hello From Modal</h3>
                <p> Testing modal window.
                </p>
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


            
        </section>
    )
}