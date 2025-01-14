export function formatDate(dateString: string | undefined): string {
  if (!dateString) return "Ej skickad";
  const options: Intl.DateTimeFormatOptions = {
    year: "numeric",
    month: "long",
    day: "numeric",
    hour: "2-digit",
    minute: "2-digit",
  };
  return new Date(dateString).toLocaleDateString("sv-SE", options);
}

export function formatPrice(price: number): string {
  return new Intl.NumberFormat("sv-SE", {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  }).format(price);
}
