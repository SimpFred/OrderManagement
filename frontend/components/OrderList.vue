<template>
  <div class="container mx-auto p-4">
    <div class="max-w-5xl mx-auto p-6">
      <div class="flex md:flex-row flex-col mb-6">
        <h1 class="text-3xl font-bold mb-6 text-center text-gray-800">
          Beställningar
        </h1>
        <div class="mb-6 flex max-md:mx-auto ml-auto items-center space-x-4">
          <input
            v-model="searchQuery"
            type="text"
            placeholder="Sök"
            class="w-full p-2 border border-gray-300 rounded-lg"
          />
          <select
            v-model="searchCriteria"
            class="p-2 border cursor-pointer border-gray-300 rounded-lg"
          >
            <option value="id">Order ID</option>
            <option value="name">Kundnamn</option>
            <option value="date">Datum</option>
          </select>
        </div>
      </div>
      <div v-if="filteredOrders.length > 0">
        <div class="space-y-4 max-w-5xl mx-auto">
          <OrderCard
            v-for="order in filteredOrders"
            :key="order.id"
            :order="order"
          />
        </div>
      </div>
      <div v-else>
        <p class="text-center text-gray-500">Det finns inga ordrar</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import { useFetch } from "#app";
import type { Order } from "~/types";
import OrderCard from "~/components/OrderCard.vue";

const orders = ref<Order[]>([]);
const searchQuery = ref<string>("");
const searchCriteria = ref<string>("id");

const { data, error } = await useFetch<Order[]>(
  "http://localhost:5025/api/orders"
);

if (error.value) {
  console.error("Error fetching orders:", error.value);
} else {
  orders.value = data.value ?? [];
}

// Computed property to filter and sort orders based on search query and criteria
const filteredOrders = computed(() => {
  const query = searchQuery.value.toLowerCase();
  const filtered = orders.value.filter((order) => {
    if (searchCriteria.value === "id") {
      return order.id.toString().includes(query);
    } else if (searchCriteria.value === "name") {
      return order.customer.name.toLowerCase().includes(query);
    } else if (searchCriteria.value === "date") {
      const formattedCreatedAt = formatDate(order.createdAt).toLowerCase();
      return formattedCreatedAt.includes(query);
    }
    return false;
  });

  // Sort orders by date, newest first
  return filtered.sort((a, b) => {
    const dateComparison =
      new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime();
    if (dateComparison !== 0) {
      return dateComparison;
    }
    return b.id - a.id; // Sort by order ID if dates are the same
  });
});
</script>
