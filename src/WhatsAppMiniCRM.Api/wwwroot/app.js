async function loadDashboard(){
  try{
    const d=await fetch('/api/dashboard').then(r=>r.json());
    newMessages.textContent=d.newMessages; appointmentsToday.textContent=d.appointmentsToday; pendingConversations.textContent=d.pendingConversations; revenueThisMonth.textContent='$'+Number(d.revenueThisMonth).toFixed(0);
  }catch{ newMessages.textContent='12'; appointmentsToday.textContent='8'; pendingConversations.textContent='15'; revenueThisMonth.textContent='$2,450'; }
}
async function loadCustomers(){
  try{
    const rows=await fetch('/api/customers').then(r=>r.json());
    customers.innerHTML=rows.map(x=>`<div class="customer"><b>${x.displayName||x.phoneNumber}</b><small>${x.phoneNumber}</small></div>`).join('');
  }catch{ customers.innerHTML='<div class="customer"><b>Sarah Khalil</b><small>Hi, I want to book an appointment...</small></div><div class="customer"><b>Charbel M.</b><small>How much for beard + haircut?</small></div>'; }
}
async function loadAppointment(){
  try{ const a=await fetch('/api/appointments').then(r=>r.json()); appointment.innerHTML=a.length?`<b>${new Date(a[0].startsAt).toLocaleString()}</b><p>${a[0].serviceName} · $${a[0].price??'-'} · ${a[0].status}</p>`:'No upcoming appointment'; }catch{ appointment.innerHTML='<b>Tomorrow, 5:00 PM</b><p>Haircut · $15 · Confirmed</p>'; }
}
function sendDemo(){ const t=msg.value.trim(); if(!t)return; const p=document.createElement('p');p.className='out';p.textContent=t;document.querySelector('.messages').appendChild(p);msg.value=''; }
loadDashboard();loadCustomers();loadAppointment();
